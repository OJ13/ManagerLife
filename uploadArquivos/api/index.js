const express = require('express');
const multer = require('multer');

const server = express();

server.get('/testeUpload/:id', (req, res) => {
    const id = req.params.id;

    return res.send(`TESTANDO O PARAMETRO DE ID: ${id}`);
});

server.listen(3000);