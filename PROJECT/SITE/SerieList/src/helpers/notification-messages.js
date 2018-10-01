const obj = {
  title: '',
  message: ''
}

export default {
  Error () {
    obj.title = 'Erro'
    obj.message = 'Ocorreu um erro não identificado'
    return obj
  }
}
