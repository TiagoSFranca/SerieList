<template>
      <v-container fluid fill-height>
        <v-layout align-center justify-center>
          <v-flex xs12 sm8 md4>
            <v-card class="elevation-12" light>
              <v-toolbar dark color="primary">
                <v-toolbar-title>Entrar</v-toolbar-title>
              </v-toolbar>
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
                    <v-checkbox
                    label="Manter conectado"
                    v-model="keep"
                    ></v-checkbox>
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
export default {
  data: () => ({
    name: 'Login',
    drawer: null,
    valid: true,
    login: '',
    keep: false,
    loginRules: [
      v => !!v || 'Usuário ou Email é obrigatório'
    ],
    password: '',
    passwordRules: [
      v => !!v || 'Senha é obrigatório'
    ]
  }),
  methods: {
    submit () {
      if (this.$refs.form.validate()) {
        AccessControlService.Auth(this.login, this.password, this.keep)
      }
    }
  }
}
</script>
