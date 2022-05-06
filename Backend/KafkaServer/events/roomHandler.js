module.exports = (io, socket) => {
    const joinRoom  = (roomId) => {
        socket.join(roomId)
        console.log(`${socket.id} has joined the room ${roomId}`)
    }

    socket.on('room:join', joinRoom)
}