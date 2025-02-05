const express = require('express');
const bodyParser = require('body-parser');
const config = require('config');
const consign = require('consign');
const multer = require('multer');
const fs = require('fs');

module.exports = () => {
    const app = express();

    //VARIAVEL DE APLICACAO
    app.set('port', process.env.PORT || config.get('server.port'));

    // MIDDLEWARES
    app.use(bodyParser.json());

    // CONFIGURACAO STORAGE
    app.storage = multer.diskStorage({
        destination: (req, file, cb) => {
            const pastaUpload = `uploads/${req.params?.id}`;

            if (!fs.existsSync(pastaUpload))
                fs.mkdirSync(pastaUpload, { recursive: true });

            cb(null, pastaUpload)
        },
        filename: (req, file, cb) => {
            const arquivoRecebido = file.originalname.split('.');
            const nomeArquivo = arquivoRecebido[0];
            const extensaoArquivo = arquivoRecebido[1];
            
            cb(null, `${nomeArquivo}.${extensaoArquivo}`);
        }
    });

    //ENDPOINTS
    consign({ cwd: 'api'})
        .then('data')
        .then('controllers')
        .then('routes')
        .into(app);

    return app;
}