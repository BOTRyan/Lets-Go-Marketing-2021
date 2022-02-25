exports.PacketBuilder = {
    join(responseID, room) {
        const packet = Buffer.alloc(9);

        packet.write("JOIN", 0);
        packet.writeUInt8(responseID, 4);

        if(responseID == 1) packet.write(room, 5);
        else packet.write("NULL", 5);

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
        const packet = Buffer.alloc(62);

        packet.write("GAME", 0);
        packet.writeUInt8(game.currTurn, 4);
        // Continue once game class is built
    },
    card(field) {

    },
    final() {

    },
    reset() {
        const packet = Buffer.alloc(4);
        packet.write("RSET");

        return packet;
    },
    



}