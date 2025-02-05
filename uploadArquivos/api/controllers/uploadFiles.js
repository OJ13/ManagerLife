const multer = require('multer');
const qtdMaxFotos = require('config').get('upload.quantidadeMaxima');

module.exports = app => {
    const controller = {}
    const storage = app.storage;
    const upload = multer({ storage }).array('foto', qtdMaxFotos);
    
    controller.uploadArquivo = (req, res) => {
        upload(req, res, (err) => {
            
            if (err) {
              console.error(err);
              return res.status(500).json({ error: err });
             }
            if (!req.files) {
               return res.status(400).json({ error: 'Por favor envie o arquivo' });
             }
             res.send('Arquivo Carregado!');
        });
    }

    return controller;
}


// module.exports = app => {
//     const controller = {}
//     const storage = app.storage;
//     const upload = multer({ storage });
    
//     controller.uploadArquivo = upload.single('foto'), (req, res) => {
//         const id = req.params.id;
//         const { nome, site } = req.body;
//         console.log('TESTE > ', id, nome, site)
//         return res.status(200).json('Upload feito com sucesso!');
//     }

//     return controller;
// }


// module.exports = app => {
//     const controller = {}
//     const storage = app.storage;
//     const upload = multer({ storage });
    
//     controller.uploadArquivo = upload.single('foto'), (req, res) => {
//         const id = req.params.id;
//         const { nome, site } = req.body;

//         console.log(id, req.body);

//         const teste = {
//             id: id,
//             nome: 'Upload Files - Osmar Junior'
//         };

//         return res.status(200).json(teste);
//     }

//     return controller;
// }