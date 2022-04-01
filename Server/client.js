const PacketBuilder = require("./packetBuilder.js").PacketBuilder;

exports.Client = class Client {
    constructor(socket, server) {
        this.socket = socket;
        this.server = server;
        this.room = "";

        this.username = "";
        this.avatar = 0;
        this.turnNum = 0;
        this.finishPlace = 0;
        this.isHost = false;
        this.buffer = Buffer.alloc(0);

        this.socket.on("error", (e) => this.onError(e));
        this.socket.on("close", () => this.onClose());
        this.socket.on("data", (d) => this.onData(d));
    };

    onError(msg) {
        console.log("ERROR with client: " + msg);
    };
    onClose() {
        this.server.onClientDisconnect(this);
    };
    onData(data) {
        this.buffer = Buffer.concat([this.buffer,data]);

        if(this.buffer.length < 4) return;

        const packetIdentifier = this.buffer.slice(0, 4).toString();

        switch(packetIdentifier) {
            case "JOIN":
                if(this.buffer.length < 8) return;
                this.room = this.buffer.slice(4, 8).toString();
                let responseID = this.server.joinResponse(this);
                this.buffer = this.buffer.slice(8);

                
                if(responseID == 1) {
                    const packetJ1 = PacketBuilder.join(responseID, this.room);

                    this.sendPacket(packetJ1);    
                }
                
                if(responseID == 2) {
                    this.turnNum = this.server.getPlayersInRoom(this.room);
                    const packetL = PacketBuilder.lobby(this.turnNum);
                    this.server.sendToHost(this.room, packetL);

                    let avatars = [];
                    for(let i = 0; i < 6; i++) {
                        avatars[i] = this.server.checkAvatar(i + 1, this.room);
                    }
                    const packetJ2 = PacketBuilder.join(responseID, avatars);
                    this.sendPacket(packetJ2);
                    
                }
                break;
            case "REDY":
                if(this.buffer.length < 5) return;

                let usernameLength = this.buffer.readUInt8(4);

                if(this.buffer.length < 5 + usernameLength) return;

               
                const avatarInput = this.buffer.readUInt8(5);
                const usernameInput = this.buffer.slice(6, 6 + usernameLength).toString();

                let responseType = this.server.usernameResponse(usernameInput, this);
                let avatarResponse = this.server.checkAvatar(avatarInput, this.room);

                if(responseType == 1 && avatarResponse == 1){
                    this.username = usernameInput;
                    this.avatar = avatarInput;

                    const packetH = PacketBuilder.hostLobbyUpdate(this.turnNum, this.avatar, this.username);
                    this.server.sendToHost(this.room, packetH);

                    let avatars = [];
                    for(let i = 0; i < 6; i++) {
                        avatars[i] = this.server.checkAvatar(i + 1, this.room);
                    }

                    const packetP = PacketBuilder.playerLobbyUpdate(avatars);
                    this.server.broadcastPacketToRoom(packetP, this.room);
                } 
                
                this.buffer = this.buffer.slice(6 + usernameLength);
                const packetR = PacketBuilder.ready(responseType, avatarResponse);

                this.sendPacket(packetR);

                break;
            case "STRT":
                this.server.lockedRooms.push(this.room);

                this.buffer.slice(4);
                const packetS = PacketBuilder.update(this.server.game);
                // TODO JARED: Broadcast packet to room, including host
                break;
            case "SPIN":
                if(this.buffer.length < 5) return;
                break;
            case "LAND":
                if(this.buffer.length < 6) return;

                let cardType = this.buffer.readUInt8(4);
                if(cardType == 4) {
                    let categoryNum = this.buffer.readUint8(5);
                    if(categoryNum == 0) return;
                    //TODO JOURNEY: Grab a number based on the categoryNum
                }
                this.buffer = this.buffer.slice(6);
                // TODO JOURNEY: Construct a CARD packet to send either to one or several players, and the host
                break;
            case "CARD":
                if(this.buffer.length < 5) return;
                let actionType = this.buffer.readUInt8(4);
                if(actionType == 1) {
                    //TODO JOURNEY: Construct a MOVE packet with the appropriate number of spaces to move
                }
                else if(actionType == 2) {
                    //TODO JOURNEY: Construct a CUPD packet to send to host
                }
                else {
                    return;
                }
                break;
            case "ENDT":
                break;
            case "CRER":
                break;
        }
    };
    sendPacket(packet) {
        this.socket.write(packet);
    }
}