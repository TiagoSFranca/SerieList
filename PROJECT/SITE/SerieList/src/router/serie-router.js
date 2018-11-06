import SerieAll from '@/components/Serie/All'
import SerieAdd from '@/components/Serie/Add'
import auth from '@/middleware/auth'

export default [
  {
    path: '/Serie/All',
    name: 'serie.all',
    component: SerieAll,
    meta: {
      title: 'Listar Séries'
    }
  },
  {
    path: '/Serie/Add',
    name: 'serie.add',
    component: SerieAdd,
    meta: {
      title: 'Adicionar Série',
      middleware: auth
    }
  }
]
