
(function () {
    var app = angular.module('store', []);

    app.controller('StoreController', function ($scope, $http) {
        ctrl = this;
        ctrl.mensagem = "teste";
        ctrl.grupos = [];
        ctrl.grupoSelecionado = {"nome":"", "mensagens":[]};
        ctrl.mensagensDisponiveis = [];
        ctrl.mensagemSelecionada = { "nome": "", "xml": "", "html": "",};


        ctrl.init = function () {
            ctrl.getGrupos();
        };

        ctrl.getGrupos = function () {
           
            $http({
                method: 'GET',
                url: 'http://localhost:56098/api/Mensagem'
            }).then(function (response) {
                ctrl.grupos = response.data;
            }, function (error) {

            });
        };

        ctrl.getMensagensDoGrupo = function () {

            $http({
                method: 'GET',
                url: 'http://localhost:56098/api/MensagensDoGrupo?grupo=' + ctrl.grupoSelecionado
                
            }).then(function (response) {
                ctrl.mensagensDisponiveis = response.data;
            }, function (error) {

            });
        };
        ctrl.exibe = function () {
            $('#output').append(ctrl.mensagemSelecionada);
        };

    });

})();