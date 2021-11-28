const Client = require("./client.js").Client;
const PacketBuilder = require("./packetBuilder.js").PacketBuilder;

exports.Server = {
    port: 8080,
    clients: [],
    rooms: [],
    maxPlayers: 7,
    start(game) {
        this.game = game;

        this.socket = require("net").createServer({}, c => this.onClientConnect(c))
    },
    onClientConnect(socket) {
        const client = new Client(socket, this);
        this.clients.push(client);
    },
    onClientDisconnect(client) {

    },
    onError(e) {
        console.log("ERROR with listener: " + e);
    },
    onStartListen() {
        console.log("The server is now listening on port " + this.port);
    },
    reachedMaxPlayers() {
        return (this.clients.length >= this.maxPlayers);
    },
    broadcastPacket(packet, room) {
        for(const i in this.clients) {
            if(this.clients[i].room == room) this.clients[i].sendPacket(packet);
        }
    },
    sendToHost(room, packet) {
        for(const i in this.clients) {
            if(this.clients[i].room == room) {
                if(this.clients[i].isHost) this.clients[i].sendPacket(packet);
            }
        }
    },
    joinResponse(client) {
        if(!this.rooms.includes(client.room)) return 4;
        
        let count = 0;

        for(const i in this.clients) {
            if(this.clients[i].room == client.room) count++;
        }
        if(count == 0){ 
            this.createRoom(client);
            client.isHost = true;
            return 1;
        }
        else if (count > this.maxPlayers) return 3;

        return 2;

    },
    usernameResponse(desiredUsername, client) {
        if(desiredUsername.length == 0) return 2;
        if(desiredUsername.length > 12) return 3;
        
        const regex1 = /^[a-zA-Z0-9\[\]]+$/;
        if(!regex1.test(desiredUsername)) return 4;

        let isUsernameTaken = false;
        this.clients.forEach(c=> {
            if(c.room != client.room) return;
            if(c.username == desiredUsername) isUsernameTaken = true;
        });
        if(isUsernameTaken) return 5;
        
        const regex2 = /(fuck|shit|damn|hell|piss|cunt)/i;

        if(regex2.test(desiredUsername)) return 6;

        
    },
    checkAvatar(num) {
        for(const i in this.clients) {
            if(this.clients[i].avatar == num) return 1;
        }

        return 0;
    },
    createRoom(host) {
        let result = "";
        let pool = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        for(let i = 0; i < 4; i++) {
            result += pool.charAt(Math.floor(Math.random() * pool.length));
        }

        while(this.rooms.includes(result)) {
            result = "";
            for(let i = 0; i < 4; i++) {
                result += pool.charAt(Math.floor(Math.random() * pool.length));
            }
        }

        host.room = result;
        this.rooms.push(result);
    }


}