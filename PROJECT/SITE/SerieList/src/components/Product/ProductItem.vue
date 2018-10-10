<template>
  <v-layout row>
    <v-flex xs12 sm12>
      <v-card>
        <v-card-title primary-title>
          <div>
            <div class="display-3">{{product.ProductInfo.Title}}</div>
            <div>
            </div>
          </div>
        </v-card-title>
        <v-card-actions>
            <v-tooltip bottom>
                <v-btn icon slot="activator">
                    <v-icon>person</v-icon>
                </v-btn>
                <span>{{product.User.UserInfo.FirstName}}</span>
            </v-tooltip>
            <v-spacer></v-spacer>
            <v-btn icon>
            <v-icon>favorite</v-icon>
            </v-btn>
            <v-btn icon>
            <v-icon>bookmark</v-icon>
            </v-btn>
            <v-btn icon>
            <v-icon>share</v-icon>
            </v-btn>
        </v-card-actions>
        <v-card-actions>
          <v-btn flat>Share</v-btn>
          <v-btn flat color="purple">Explore</v-btn>
          <v-spacer></v-spacer>
          <v-btn icon @click="show = !show">
            <v-icon>{{ show ? 'keyboard_arrow_down' : 'keyboard_arrow_up' }}</v-icon>
          </v-btn>
        </v-card-actions>

        <v-slide-y-transition>
          <v-card-text v-show="show">
            {{product.ProductInfo.Description}}
          </v-card-text>
        </v-slide-y-transition>
      </v-card>
    </v-flex>
  </v-layout>
</template>

<script>
export default {
  props: ['product'],
  data: () => ({
    show: false
  })
}
</script>
