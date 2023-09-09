<template>
    <div>
        <div class="announcement-list">
            <div v-for="item in items" :key="item.id" @click="openAnnouncement(item.id)" class="announcement-item">
                <div class="announcement-image">
                    <img :src="item.imageUrl" alt="Announcement Image" />
                </div>
                <div class="announcement-details">
                    <h2>{{ item.title }}</h2>
                    <p class="description">{{ item.description }}</p>
                    <p class="price">{{ item.price }} грн</p>
                </div>
            </div>
        </div>
        <div class="center-button">
            <button @click="createNewAnnouncement" class="create-button">Створити оголошення</button>
        </div>
    </div>
</template>

<script setup>
import axios from 'axios'
import { onMounted, ref } from 'vue'
import router from '../routes/index'

const items = ref([])

const openAnnouncement = (id) => {
    router.push(`/announcement/${id}`)
}

const createNewAnnouncement = () => {
    // Додайте код для створення нового оголошення тут
    // Наприклад, перенаправлення на сторінку створення оголошення
    router.push('/create-announcement')
}

onMounted(async () => {
    const response = await axios.get('https://localhost:44315/api/Advertisement?pageNumber=1&pageSize=10&sortBy=priceAsc')
    items.value = response.data.result
    console.log(response)
})
</script>

<style scoped>
.announcement-list {
    display: flex;
    flex-wrap: wrap;
    gap: 20px;
}

.announcement-item {
    border: 1px solid #ddd;
    padding: 10px;
    border-radius: 5px;
    cursor: pointer;
    transition: transform 0.2s;
    flex: 1;
    min-width: 300px;
}

.announcement-item:hover {
    transform: scale(1.03);
}

.announcement-image img {
    max-width: 100%;
    height: auto;
}

.announcement-details {
    margin-top: 10px;
}

h2 {
    font-size: 1.2rem;
    margin: 0;
}

.description {
    font-size: 0.9rem;
    color: #555;
    margin: 0;
}

.price {
    font-size: 1rem;
    color: #333;
    margin: 0;
    font-weight: bold;
}

.center-button {
    display: flex;
    justify-content: center;
    align-items: center;
    margin-top: 20px;
}

.create-button {
    padding: 10px 20px;
    background-color: #42b983;
    color: white;
    border: none;
    border-radius: 5px;
    cursor: pointer;
    font-size: 1rem;
    transition: background-color 0.2s;
}

.create-button:hover {
    background-color: #319c75;
}
</style>
