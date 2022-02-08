const server = require("./server").Server;
const PacketBuilder = require("./packetBuilder.js").PacketBuilder;

const Game = {
    currTurn: 1,
    board: [],
    players: [],
    moveSpace(client, spinNum) {

    },
    checkLandedSpace(pos) {

    },
    sendToCareerScreen() {

    }

}

server.start(Game);