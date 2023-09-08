<template>
  <!--  <button @click="cresteNewAnnounement">створити об'яву</button>-->
    <div v-for="item in items" :key="item.id" @click="openAnnouncement(item.id)">
        <p>{{item.title}}</p>
    </div>
</template>

<script setup>
import axios from 'axios'
import {onMounted, ref} from 'vue'
import router from '../routes/index'
const items = ref([])
const openAnnouncement = (id)=>{
    router.push(`/announcement/${id}`)
}

// const createNewAnnouncement = () => {
//     const {data} = axios.post('http://localhost:5000')
// }
onMounted(async ()=>{
    const response = await axios.get('https://localhost:44315/api/Advertisement?pageNumber=1&pageSize=10&sortBy=SomeSortField')
    items.value = response.data.result
    console.log(response)
})


</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
    margin: 40px 0 0;
}
ul {
    list-style-type: none;
    padding: 0;
}
li {
    display: inline-block;
    margin: 0 10px;
}
a {
    color: #42b983;
}
</style>
