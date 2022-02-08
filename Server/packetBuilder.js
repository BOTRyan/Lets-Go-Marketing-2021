exports.PacketBuilder = {
    join(responseID, room) {
        const packet = Buffer.alloc(9);

        packet.write("JOIN", 0);
        packet.writeUInt8(responseID, 4);

        if(responseID == 1) packet.write(room, 5);
        else packet.write("NULL", 5);

        return packet;
    },
    ready(usernameResponse, server) {
        const packet = Buffer.alloc(11);

        packet.write("REDY", 0);
        packet.writeUInt8(usernameResponse, 4);
        for(let i = 0; i < 6; i++) {
            packet.writeUInt8(server.checkAvatars(i), 5 + i);
        }

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