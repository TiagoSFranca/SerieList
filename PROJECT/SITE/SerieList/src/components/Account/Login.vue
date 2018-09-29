<template>
      <v-container fluid fill-height>
        <v-layout align-center justify-center>
          <v-flex xs12 sm8 md4>
            <v-card class="elevation-12">
              <v-card-text>
                <v-form>
                  <v-text-field prepend-icon="person" name="login" label="Usuário ou Email" type="text"></v-text-field>
                  <v-text-field id="password" prepend-icon="lock" name="password" label="Senha" type="password"></v-text-field>
                </v-form>
              </v-card-text>
              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="primary">Entrar</v-btn>
              </v-card-actions>
            </v-card>
          </v-flex>
        </v-layout>
      </v-container>
</template>

<script>
export default {
  name: 'Login',
  data: () => ({
    drawer: null
  }),
  props: {
    source: String
  },
  created: function () {
    this.$emit('on-page-title-change', 'Entrar')
  }
}
</script>
