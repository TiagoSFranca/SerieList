import moment from 'moment'

export default {
  FormatDate (date) {
    return date ? moment(date).format('DD/MM/YYYY') : ''
  }
}
