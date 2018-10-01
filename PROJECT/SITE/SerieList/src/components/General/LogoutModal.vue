<template v-if="dialog">
  <v-layout row justify-center>
    <v-dialog v-model="dialog" max-width="320">
      <v-card>
        <v-card-title class="headline">Sair</v-card-title>
        <v-card-text class="title">
          Deseja realmente sair?
        </v-card-text>

        <v-card-actions>
          <v-spacer></v-spacer>

          <v-btn class="error" flat="flat" outline @click="dialog = false">
            Cancelar
          </v-btn>

          <v-btn class="primary" flat="flat" outline @click="logout">
            Sair
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-layout>
</template>

<script>
import AccessControlService from '@/api-services/access-control'
import NotificationMessages from '@/helpers/notification-messages'
import AuthHelper from '@/helpers/auth'
export default {
  data () {
    return {
      dialog: false
    }
  },
  methods: {
    showModal (value) {
      this.dialog = value
    },
    logout () {
      this.showModal(false)
      AccessControlService.Unauth()
        .then((response) => {
          var data = response.data
          console.log(data)
          if (data.Success === true) {
            AuthHelper.removeToken()
            this.$toast.success({
              title: data.Method,
              message: data.Message
            })
            this.$router.push('Home')
          } else {
            this.$toast.error({
              title: data.Method,
              message: data.Exception.ErrorMessage
            })
          }
        }).catch(error => {
          console.log(error)
          this.$toast.error(NotificationMessages.Error())
        })
    }
  }
}
</script>
