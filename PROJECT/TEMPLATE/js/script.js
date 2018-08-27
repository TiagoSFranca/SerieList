; (function (window, document, $) {
    'use strict';
    var App = (function () {
        var _public = {};
        var _private = {};
        _private.Usuario = [
          { Email: 'Admin@mail.com', login: 'admin', senha: 'admin' }
        ];
        var _listCategoria = [
          { id: '0', Nome: 'Ação', Imagem: 'img/acao.png' }
          , { id: '1', Nome: 'Aventura', Imagem: 'img/aventura.png' }
          , { id: '2', Nome: 'Comédia', Imagem: 'img/comedia.png' }
          , { id: '3', Nome: 'Drama', Imagem: 'img/drama.png' }
          , { id: '4', Nome: 'Ficção Científica', Imagem: 'img/ficcao.png' }
          , { id: '5', Nome: 'Musical', Imagem: 'img/musical.png' }
          , { id: '6', Nome: 'Terror', Imagem: 'img/terror.png' }

        ];

        var _listSerie = [
          {
              id: '0',
              Titulo: 'Bones',
              Diretor: 'Hart Hanson',
              Ano: '2005',
              Descricao: '',
              Url: 'http://www.fox.com/bones',
              Imagem: 'img/bones.png',
              idCategoria: '0'
          },
          {
              id: '1',
              Titulo: 'CSI',
              Diretor: 'Anthony E. Zuiker',
              Ano: '2000',
              Descricao: 'Sangue e Morte',
              Url: '',
              Imagem: 'img/csi.png',
              idCategoria: '0'
          },
          {
              id: '2',
              Titulo: 'Desperate Housewives',
              Diretor: 'Marc Cherry',
              Ano: '2004',
              Descricao: '',
              Url: '',
              Imagem: 'img/desperateHousewives.png',
              idCategoria: '1'
          },
          {
              id: '3',
              Titulo: 'Doctor Who',
              Diretor: '',
              Ano: '',
              Descricao: '',
              Url: '',
              Imagem: 'img/doctorWho.png',
              idCategoria: '1'
          },
          {
              id: '4',
              Titulo: 'Extreme Makeover',
              Diretor: '',
              Ano: '',
              Descricao: '',
              Url: '',
              Imagem: 'img/extremeMakeover.png',
              idCategoria: '2'
          },
          {
              id: '5',
              Titulo: 'Friends',
              Diretor: '',
              Ano: '',
              Descricao: '',
              Url: '',
              Imagem: 'img/friends.png',
              idCategoria: '2'
          },
          {
              id: '6',
              Titulo: 'Glee',
              Diretor: '',
              Ano: '',
              Descricao: '',
              Url: '',
              Imagem: 'img/glee.png',
              idCategoria: '5'
          },
          {
              id: '7',
              Titulo: 'Lost',
              Diretor: '',
              Ano: '',
              Descricao: '',
              Url: '',
              Imagem: 'img/lost.png',
              idCategoria: '3'
          },
          {
              id: '8',
              Titulo: 'NCIS',
              Diretor: 'Dennis Smith, Thomas J. Wright, Terrence OHara, James Whitmore Jr.',
              Ano: '2003',
              Descricao: 'Irregular',
              Url: '',
              Imagem: 'img/NCIS.png',
              idCategoria: '4'
          },
          {
              id: '9',
              Titulo: 'Sex And The City',
              Diretor: '',
              Ano: '',
              Descricao: '',
              Url: '',
              Imagem: 'img/SexCity.png',
              idCategoria: '2'
          },
        ];


        //VARIAVEIS
        //BOTÕES
        var login = document.getElementById('btn_login');
        var senha = document.getElementById('btn_senha');

        //OUTROS ELEMENTOS
        var divSerieAdd = document.getElementById('dv_serie_add');
        var divCategoria = document.getElementById('dv_categoria_all');
        var divSerie = document.getElementById('dv_serie_all');
        var spnUsuario = document.getElementById('spn_usuario');

        //NOVOS ELEMENTOS
        var novaDiv = document.createElement('DIV');
        var novaDescricao = document.createElement('h3');
        var novaImagem = document.createElement('IMG');
        var novoInput = document.createElement('input');
        var novoLabel = document.createElement('label');
        var novoSpan = document.createElement('span');




        _private.login = function (usuario, senha) {
            var flag = 0;
            _private.Usuario.forEach(function (obj) {
                if (obj.login === usuario && obj.senha === senha) {
                    flag = 1;
                    window.open('home.html?login=' + obj.login, '_self');
                }
            });
            if (!flag) {
                alert('Login ou Senha inválidos!');
            };
        };

        _private.cadastrarSerie = function (obj) {
            _listSerie.push(obj);
            _listSerie.forEach(function (e) {
                console.log(e);
            })
        };

        //CHECAR USUARIO JA CADASTRADO
        _private.checarLogin = function (usuario) {
            var flag = 0;
            _private.Usuario.forEach(function (obj) {
                if (obj.login === usuario) {
                    flag = 1;
                }
            });
            return flag;
        };



        //CADASTRAR USUÁRIO
        _private.cadastrarUsuario = function (obj) {
            _private.Usuario.push(obj);
            _private.Usuario.forEach(function (e) {
                console.log(e);
            })
        };


        _private.editarSerie = function (objeto, indice) {
            console.log(_listSerie[indice]);
            _listSerie.splice(indice, 1, objeto);
            console.log(_listSerie[indice]);
        };

        _private.deletarSerie = function (indice) {
            _listSerie.splice(indice, 1);
            console.log(_listSerie);
        };
        //CHECAR sE CAMPO ESTÁ VAZIO
        _public.checarVazio = function (obj) {
            var tamanho = obj.length;
            var flag = 1;
            for (var i = tamanho - 1; i >= 0; i--) {
                if (obj[i] != ' ') {
                    flag = 0;
                };
            };
            return flag;
        };


        //CHECAR SÉRIE JA CADASTRADA
        _public.checarSerie = function (serie) {
            var flag = 0;
            _listSerie.forEach(function (obj) {
                if (obj.Titulo === serie) {
                    flag = 1;
                };
            });
            return flag;
        };

        //ABRIR PAGINAS
        _public.paginas = function () {
            $('#btn_inicio').click(function () {
                window.open('home.html', '_self');
            });
            $('#btn_categoria').click(function () {
                window.open('categoria.html', '_self');
            });
            $('#btn_categoria_spn').click(function () {
                window.open('categoria.html', '_self');
            });
            $('#btn_categoria_add').click(function () {
                window.open('categoria_add.html', '_self');
            });
            $('#btn_serie_add').click(function () {
                window.open('serie_add.html', '_self');
            });
            $('#btn_serie').click(function () {
                window.open('serie.html', '_self');
            });
            $('#btn_serie_spn').click(function () {
                window.open('serie.html', '_self');
            });
            $('#btn_serie_return').click(function () {
                window.open('serie.html', '_self');
            });
            $('#btn_serie_edit').click(function () {
                var $this = $(this);
                window.open('serie_edit.html?id=' + $this.attr('class'), '_self');
            });
            $(divSerieAdd).click(function () {
                window.open('serie_add.html', '_self');
            });
            $('.categoriaList').click(function () {
                var $this = $(this);
                window.open('categoria_list.html?id=' + $this.attr('id'), '_self');
            });
            $('.serieList').click(function () {
                var $this = $(this);
                window.open('serie_info.html?id=' + $this.attr('id'), '_self');
            });
            $('#btn_categoria_return').click(function () {
                window.open('categoria.html', '_self');
            });
            $('#spn_categoria_list').click(function () {
                window.open('categoria.html', '_self');
            });
            $('#spn_serie_list').click(function () {
                window.open('serie.html', '_self');
            });
            $('#btn_sair').click(function () {
                var confimar = confirm('Tem certeza que deseja Sair?');
                if (confimar) {
                    window.open('index.html', '_self');
                };
            });

        };

        //DELETAR SERIE
        $('#btn_serie_delete').click(function () {
            if (confirm('Tem Certeza que Deseja DELETAR?\n')) {
                console.log(_listSerie);
                var valor = _public.getUrl(window.location.href.toString());
                _private.deletarSerie(valor);
                alert('Série DELETADA Com Sucesso!\n');
                window.open('serie.html', '_self');
            }
        })
        //LISTAR CATEGORIA
        _public.listarCategoria = function () {
            var qtdCategoria = _listCategoria.length;
            novaDiv.className = 'categoriaList';
            for (var i = 0; i < qtdCategoria; i++) {
                if (divCategoria != null) {
                    if (divCategoria.className == 'home' && i == 4) {
                        break;
                    };
                    if (_listCategoria[i].Imagem === '') {
                        novaImagem.src = 'img/semCategoria.png';
                    } else {
                        novaImagem.src = _listCategoria[i].Imagem;
                    }
                    novaDescricao.innerHTML = _listCategoria[i].Nome;
                    novaDiv.id = _listCategoria[i].id;
                    novaDiv.appendChild(novaImagem);
                    novaDiv.appendChild(novaDescricao);
                    divCategoria.appendChild(novaDiv.cloneNode(true));
                };
            };
        };
        _public.listarCategoriaAdd = function () {
            var lista = document.getElementById('dv_lista_categoria');
            var br = document.createTextNode('          |   ');
            if (lista) {
                _listCategoria.forEach(function (obj) {
                    novoInput.setAttribute('id', obj.Nome)
                    novoInput.setAttribute('type', 'radio');
                    novoInput.setAttribute('value', obj.id);
                    novoInput.setAttribute('name', 'Categoria');
                    novoLabel.setAttribute('for', obj.Nome);
                    novoInput.setAttribute('required', true);
                    novoSpan.innerHTML = obj.Nome;
                    novoLabel.appendChild(novoSpan);
                    lista.appendChild(novoInput.cloneNode(true));
                    lista.appendChild(novoLabel.cloneNode(true));
                    lista.appendChild(br.cloneNode(true))
                });
            };
        };

        _public.listarCategoriaSerie = function () {
            novaDiv.className = 'serieList';
            if ($('#spn_categoria_nome').val() !== undefined) {
                var valor = _public.getUrl(window.location.href.toString());
                $('#spn_categoria_nome').html(_listCategoria[valor].Nome);
                var quantidade = 0;
                _listSerie.forEach(function (obj) {
                    if (obj.idCategoria === valor) {
                        quantidade++;
                        if (obj.Imagem === '') {
                            novaImagem.src = 'img/semCategoria.png';
                        } else {
                            novaImagem.src = obj.Imagem;
                        }
                        novaDescricao.innerHTML = obj.Titulo;
                        novaDiv.id = obj.id;
                        novaDiv.appendChild(novaImagem);
                        novaDiv.appendChild(novaDescricao);
                        $('#dv_categoria_serie_all').append(novaDiv.cloneNode(true));
                    };
                });
                if (quantidade === 0) {
                    alert('Não Foram encontradas Séries na categoria ' + _listCategoria[valor].Nome + ' !');
                    window.open('categoria.html', '_self');
                };
            };
        };

        //PEGAR URL
        _public.getUrl = function (url) {
            var tamanho = url.length;
            var saida;
            var pos = 0;
            var achou = 0;
            do {
                if (url[pos] === '=') {
                    for (var i = pos + 1 ; i < tamanho; i++) {
                        if (saida !== undefined) {
                            saida += (url[i]);
                        }
                        else {
                            saida = url[i];
                        }
                    };
                    achou = 1;
                };
                pos++;
            } while (url[pos - 1] !== '=' || achou == 0);
            return saida;
        };



        //EDITAR SÉRIE
        _public.editarSeriePreencher = function () {
            if ($('#serie_edit').html() !== undefined) {
                var valor = _public.getUrl(window.location.href.toString());

                var dvi = $('#dv_serie_imagem');
                novaImagem.id = 'img_serie';
                if (_listSerie[valor].Imagem === '') {
                    novaImagem.src = 'img/semCategoria.png';
                } else {
                    novaImagem.src = _listSerie[valor].Imagem;
                }
                dvi.append(novaImagem);

                $('#btn_serie_edit_titulo').val(_listSerie[valor].Titulo);
                $('#btn_serie_edit_diretor').val(_listSerie[valor].Diretor);
                $('#btn_serie_edit_link').val(_listSerie[valor].Url);
                $('#btn_serie_edit_ano').val(_listSerie[valor].Ano);
                $('#btn_serie_edit_imagem').val(_listSerie[valor].Imagem);
                $('input:radio[name=Categoria][id=' + _listCategoria[_listSerie[valor].idCategoria].Nome + ']').prop('checked', true);
                $('#btn_serie_edit_descricao').val(_listSerie[valor].Descricao);
            };
        };
        $('#form_edit_serie').on('submit', function (evento) {
            evento.preventDefault();
            if (confirm('Tem certeza Que Deseja ALTERAR?\n')) {
                var valor = _public.getUrl(window.location.href.toString());
                _private.editarSerie({
                    Titulo: $('#btn_serie_edit_titulo').val(),
                    Diretor: $('#btn_serie_edit_diretor').val(),
                    Ano: $('#btn_serie_edit_ano').val(),
                    Descricao: $('#btn_serie_edit_descricao').val(),
                    Url: $('#btn_serie_edit_link').val(),
                    Imagem: $('#btn_serie_edit_imagem').val(),
                    idCategoria: $("input[name='Categoria']:checked").val(),
                    id: valor
                }, valor);
                alert('Série Editada Com Sucesso!');
            }
        })


        //LISTAR SÉRIE
        _public.listarSerie = function () {
            var qtdSerie = _listSerie.length;
            novaDiv.className = 'serieList';
            for (var i = 0; i < qtdSerie; i++) {
                if (divSerie != null) {
                    if (divSerieAdd != null && i == 3) {
                        break;
                    };
                    if (_listSerie[i].Imagem === '') {
                        novaImagem.src = 'img/semCategoria.png';
                    } else {
                        novaImagem.src = _listSerie[i].Imagem;
                    }
                    novaDescricao.innerHTML = _listSerie[i].Titulo;
                    novaDiv.id = _listSerie[i].id;
                    novaDiv.appendChild(novaImagem);
                    novaDiv.appendChild(novaDescricao);
                    divSerie.appendChild(novaDiv.cloneNode(true));
                };
            };
        };

        _public.listarSerieUnica = function () {
            if ($('#spn_serie_nome').val() !== undefined) {
                var valor = _public.getUrl(window.location.href.toString());
                $('#btn_serie_edit').attr('class', _listSerie[valor].id);
                $('#spn_serie_nome').html(_listSerie[valor].Titulo);

                if (_listSerie[valor].Descricao === '') {
                    $('#spn_serie_descricao').html('Descrição Não Cadastrada');
                } else {
                    $('#spn_serie_descricao').html(_listSerie[valor].Descricao);
                }

                if (_listSerie[valor].Diretor === '') {
                    $('#spn_serie_diretor').html('Diretor Não Cadastrado');
                } else {
                    $('#spn_serie_diretor').html(_listSerie[valor].Diretor);
                }

                if (_listSerie[valor].Ano === '') {
                    $('#spn_serie_lancamento').html('Ano de Lançamento Não Cadastrado');
                } else {
                    $('#spn_serie_lancamento').html(_listSerie[valor].Ano);
                }

                if (_listSerie[valor].Url === '') {
                    $('#spn_serie_link').html('Link Externo Não Cadastrado');
                } else {
                    $('#spn_serie_link').html(_listSerie[valor].Url);
                }
                var dvi = $('#dv_serie_img');
                novaImagem.id = 'img_serie';
                if (_listSerie[valor].Imagem === '') {
                    novaImagem.src = 'img/semCategoria.png';
                } else {
                    novaImagem.src = _listSerie[valor].Imagem;
                }
                dvi.append(novaImagem);
                $('#spn_serie_categoria').html(_listCategoria[_listSerie[valor].idCategoria].Nome);
            };
        }

        //FUNÇÕES INICIAIS
        _public.init = function () {
            _public.listarSerie();
            _public.listarCategoria();
            _public.listarCategoriaAdd();
            _public.listarSerieUnica();
            _public.listarCategoriaSerie();
            _public.editarSeriePreencher();
            _public.paginas();
            $('#spn_usuario').html(_private.Usuario[0].login);
        };

        //CANCELAR
        $('#categoria_cancel').click(function () {
            var confimar = confirm('Tem certeza que deseja CANCELAR?');
            if (confimar) {
                window.open('categoria.html', '_self');
            };
        });
        $('#serie_cancel').click(function () {
            var confimar = confirm('Tem certeza que deseja CANCELAR?');
            if (confimar) {
                window.open('serie.html', '_self');
            };
        });

        //CADASTRO DE USUARIO
        $('#form_cadastro_usuario').on('submit', function (evento) {
            evento.preventDefault();
            if ($('#btn_cadastro_senha').val() !== $('#btn_cadastro_senha_cofirm').val()) {
                alert('Senhas não coincedem!');
                $('#btn_cadastro_senha').select();
            }
            else {
                var retorno = _private.checarLogin($('#btn_cadastro_login').val());
                if (retorno === 1) {
                    alert('Usuario já cadastrado');
                    $('#btn_cadastro_login').select();
                } else {
                    if (_public.checarVazio($('#btn_cadastro_login').val())) {
                        alert('Campo Vazio');
                        $('#btn_cadastro_login').select();
                    } else if (_public.checarVazio($('#btn_cadastro_senha').val())) {
                        alert('Campo Vazio');
                        $('#btn_cadastro_senha').select();
                    } else {
                        _private.cadastrarUsuario({
                            Email: $('#btn_cadastro_email').val(),
                            login: $('#btn_cadastro_login').val(),
                            senha: $('#btn_cadastro_senha').val()
                        });
                        alert('Cadastro realizado com sucesso!');
                        window.open('home.html', '_self');
                    }
                }
            }
        });

        //CADASTRO DE SÉRIE
        $('#form_cadastro_serie').on('submit', function (evento) {
            evento.preventDefault();
            if (_public.checarVazio($('#btn_serie_new_titulo').val())) {
                alert('Campo Vazio');
                $('#btn_serie_new_titulo').select();
            } else {
                if (_public.checarSerie($('#btn_serie_new_titulo').val())) {
                    alert('Série Já Cadastrada');
                    $('#btn_serie_new_titulo').select();
                } else {
                    _private.cadastrarSerie({
                        Titulo: $('#btn_serie_new_titulo').val(),
                        Diretor: $('#btn_serie_new_diretor').val(),
                        Ano: $('#btn_serie_new_ano').val(),
                        Descricao: $('#btn_serie_new_descricao').val(),
                        Url: $('#btn_serie_new_link').val(),
                        Imagem: $('#btn_serie_new_imagem').val(),
                        idCategoria: $("input[name='Categoria']:checked").val()
                    });
                    alert('Série Cadastrada Com Sucesso!');
                    window.open('serie.html', '_self');
                }
            }
        });


        //LOGIN
        $('#form_entrar').on('submit', function (evento) {
            evento.preventDefault();
            _private.login(login.value, senha.value);
        });


        return _public;
    }
    )();
    window.App = App;
    App.init();
}

)(window, document, jQuery);
