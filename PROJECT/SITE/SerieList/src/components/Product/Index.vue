<template>
  <v-container fluid grid-list-lg>
    <v-layout row wrap>
      <v-flex xs12 sm12 md12>
        <v-card>
          <v-card-text>
            <v-fab-transition>
              <v-btn class="primary" absolute top left fab>
                <v-icon>add</v-icon>
              </v-btn>
            </v-fab-transition>
          </v-card-text>
        </v-card>
      </v-flex>
      <v-flex>
        <v-card>
        <v-container fluid grid-list-sm>
          <v-layout row wrap>
            <v-flex v-for="i in data.Items" :key="i.IdProduct" xs4>
                <product-item :product="i"/>
            </v-flex>
          </v-layout>
        </v-container>
        </v-card>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import ProductStatus from '@/api-services/product'
import ProductItem from '@/components/Product/ProductItem'
export default {
  name: 'Index',
  data () {
    return {
      hidden: false,
      data: {
        Items: []
      }
    }
  },
  components: {
    ProductItem
  },
  created () {
    this.$emit('on-page-title-change', 'Produtos')
    ProductStatus.search()
      .then((response) => {
        var data = response.data
        console.log(data)
        if (data.Success === true) {
          this.data = data.ResultPaged
          this.$toast.success({
            title: data.Method,
            message: data.Message
          })
        } else {
          this.$toast.error({
            title: data.Method,
            message: data.Message
          })
        }
      }).catch((error) => {
        return error.response.data
      })
  }
}
</script>
