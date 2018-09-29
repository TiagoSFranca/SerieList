<template>
<div>{{msg}}</div>
</template>

<script>
export default {
  name: 'Index',
  data () {
    return {
      msg: 'Welcome to Your Vue.js App'
    }
  },
  created () {
    this.$emit('on-page-title-change', 'Início')
  }
}
</script>
