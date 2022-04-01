const server = require("./server").Server;
const PacketBuilder = require("./packetBuilder.js").PacketBuilder;

const Game = {
    currTurn: 1,
    brandCrisisNum: 13,
    careerPointNum: 8,
    ytbNum: 8,
    dykCategories: 5,
    dykNumberPerCategory: [7, 6, 6, 7, 7],
    players: [],
    moveSpace(client, spinNum) {

    },
    sendToCareerScreen() {

    }

}

server.start(Game);