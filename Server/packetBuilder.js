exports.PacketBuilder = {
    join(responseID, roomOrArray) {
        const packet = Buffer.alloc(5 + roomOrArray.length);

        packet.write("JOIN", 0);
        packet.writeUInt8(responseID, 4);
       
        if(typeof(roomOrArray) === 'string') packet.write(roomOrArray, 5);
        else if (typeof(roomOrArray) === 'object') {
            for(let i = 0; i < roomOrArray.length; i++) {
                packet.writeUInt8(roomOrArray[i], 5 + i);
            }
        }

        return packet;
    },
    lobby(numPlayers) {
        const packet = Buffer.alloc(5);
        packet.write("LOBY", 0);
        packet.writeUInt8(numPlayers, 4);

        return packet;
    },
    hostLobbyUpdate(playerSlot, avatarNum, username) {
        let userLength = username.length;
        const packet = Buffer.alloc(7 + userLength);
        packet.write("HUPD", 0);
        packet.writeUInt8(playerSlot, 4);
        packet.writeUInt8(avatarNum, 5);
        packet.writeUInt8(userLength, 6);
        packet.write(username, 7);

        return packet;
    },
    playerLobbyUpdate(availableArray) {
        const packet = Buffer.alloc(10);

        packet.write("PUPD", 0);
        for(let i = 0; i < availableArray.length; i++) {
            packet.writeUInt8(availableArray[i], i+4);
        }

        return packet;
    },
    ready(usernameResponse, avatarResponse) {
        const packet = Buffer.alloc(6);

        packet.write("REDY", 0);
        packet.writeUInt8(usernameResponse, 4);
        packet.writeUInt8(avatarResponse, 5);


        return packet;
    },
    update(game) {
        const packet = Buffer.alloc(5);

        packet.write("GAME", 0);
        packet.writeUInt8(game.currTurn, 4);
        
        return packet;
    },
    card(numberFromField) {
        const packet = Buffer.alloc(5);
        packet.write("CARD", 0);
        packet.writeUInt8(numberFromField, 4);

        return packet;
    },
    move(moveNum) {
        const packet = Buffer.alloc(5);
        packet.write("MOVE", 0);
        packet.writeUInt8(moveNum, 4);

        return packet;
    },
    cardUpdate(playerNum) {
        const packet = Buffer.alloc(5);
        packet.write("CUPD", 0);
        packet.writeUInt8(playerNum, 4);

        return packet;
    },
    final() {

    },
    reset() {
        const packet = Buffer.alloc(4);
        packet.write("RSET");

        return packet;
    },
    



}