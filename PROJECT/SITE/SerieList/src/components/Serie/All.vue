<template dark>
    <v-flex xs12 sm12 md12 >
        <v-container fluid grid-list-sm>
            <v-layout row wrap>
                <v-flex v-for="i in result.Items" :key="i.IdProduct" xs4>
                    <serie-item :product="i"/>
                </v-flex>
            </v-layout>
        </v-container>
        <div class="fixed-bottom right">
            <v-btn fab color="primary">
                <v-icon>filter_list</v-icon>
            </v-btn>
            <v-btn fab color="primary" @click="Add">
                <v-icon>add</v-icon>
            </v-btn>
        </div>
    </v-flex>
</template>

<script>
import SerieService from '@/api-services/serie'
import SerieItem from '@/components/Serie/ListItem'
import StoreSerieConstants from '@/store/constants/serie'
import { mapGetters } from 'vuex'
export default {
  name: 'Index',
  data () {
    return {
    }
  },
  components: {
    SerieItem
  },
  created () {
    SerieService.search()
  },
  computed: {
    ...mapGetters({
      result: StoreSerieConstants.GETTERS.GET_RESULT
    })
  },
  methods: {
    Add () {
      console.log('aadw')
      this.$router.push({name: 'serie.add'})
    }
  }
}
</script>
<style>
  .fixed-bottom {
    position: fixed;
    bottom: 10px;
  }
  .right {
    right: 10px;
  }
</style>
