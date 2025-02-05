module.exports = app => {
    //const controller = require('../controllers/uploadFiles')();
    const controller = app.controllers.uploadFiles;
   
    app.route(`/api/v1/upload/:id`)
        .post(controller.uploadArquivo);
}
