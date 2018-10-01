<template>
      <v-container fluid fill-height>
        <v-layout align-center justify-center>
          <v-flex xs12 sm8 md4>
            <v-card class="elevation-12" light>
              <v-form ref="form" v-model="valid" lazy-validation
                @submit.prevent="submit">
                <v-card-text>
                    <v-text-field
                    prepend-icon="person"
                    name="login"
                    required
                    label="Usuário ou Email"
                    type="text"
                    v-model="login"
                    :rules="loginRules"></v-text-field>
                    <v-text-field
                    id="password"
                    prepend-icon="lock"
                    required
                    name="password"
                    label="Senha"
                    type="password"
                    v-model="password"
                    :rules="passwordRules"></v-text-field>
                </v-card-text>
                <v-card-actions>
                  <v-spacer></v-spacer>
                  <v-btn
                  color="primary"
                  type="submit"
                  :disabled="!valid">Entrar</v-btn>
                </v-card-actions>
              </v-form>
            </v-card>
          </v-flex>
        </v-layout>
      </v-container>
</template>

<script>
import AccessControlService from '@/api-services/access-control'
import NotificationMessages from '@/helpers/notification-messages'
import AuthHelper from '@/helpers/auth'
export default {
  name: 'Login',
  data: () => ({
    drawer: null,
    valid: true,
    login: '',
    loginRules: [
      v => !!v || 'Usuário ou Email é obrigatório'
    ],
    password: '',
    passwordRules: [
      v => !!v || 'Senha é obrigatório'
    ]
  }),
  created: function () {
    this.$emit('on-page-title-change', '')
  },
  methods: {
    showLoader (value) {
      this.$emit('on-show-loader', value)
    },
    submit () {
      if (this.$refs.form.validate()) {
        this.showLoader(true)
        AccessControlService.Auth(this.login, this.password)
          .then((response) => {
            var data = response.data
            this.showLoader(false)
            console.log(data)
            if (data.Success === true) {
              AuthHelper.setToken(data.Result)
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
            this.showLoader(false)
            this.$toast.error(NotificationMessages.Error())
          })
      }
    }
  }
}
</script>
