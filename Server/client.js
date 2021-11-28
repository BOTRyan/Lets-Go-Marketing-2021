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

                let responseID = this.server.joinResponse(this.client);
                if(responseID <= 2) this.room = this.buffer.slice(4, 4).toString();
                

                const packet = PacketBuilder.join(responseID);

                this.sendPacket(packet);
                break;
            case "REDY":
                if(this.buffer.length < 5) return;

                let usernameLength = this.buffer.readUInt8(4);

                if(this.buffer.length < 5 + usernameLength) return;

                const usernameInput = this.buffer.slice(5, 5 + lengthOfUsername).toString();
                const avatarInput = this.buffer.slice(5 + lengthOfUsername, 1);

                let responseType = this.server.usernameResponse(usernameInput, this);

                if(responseType == 1) this.username = usernameInput;
                if(this.server.checkAvatars(avatarInput) == 0) this.avatar = avatarInput;

                const packet = PacketBuilder.ready(responseType, this.server);

                this.sendPacket(packet);

                break;
            case "STRT":
                this.server.lockedRooms.push(this.room);

                const packet = PacketBuilder.update(this.server.game);
                break;
            case "SPIN":
                break;
            case "CARD":
                break;
            case "CRER":
                break;
        }
    };
    sendPacket(packet) {
        this.socket.write(packet);
    }
}