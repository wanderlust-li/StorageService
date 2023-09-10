<template>
    <div>
        <div class="sorting-options">
            <label for="sortOptions">Сортувати за:</label>
            <select id="sortOptions" v-model="selectedSortOption">
                <option value="priceAsc">Ціна (за зростанням)</option>
                <option value="priceDesc">Ціна (за спаданням)</option>
                <option value="dateCreatedAsc">Дата створення (за зростанням)</option>
                <option value="dateCreatedDesc">Дата створення (за спаданням)</option>
            </select>
            <button @click="fetchAdvertisements">Застосувати</button>
        </div>

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

let selectedSortOption = ref('priceAsc');

const fetchAdvertisements = async () => {
    const response = await axios.get(`https://localhost:44315/api/Advertisement?pageNumber=1&pageSize=10&sortBy=${selectedSortOption.value}`);
    items.value = response.data.result;
    console.log(response);
}

onMounted(fetchAdvertisements);

const openAnnouncement = (id) => {
    router.push(`/announcement/${id}`)
}

const createNewAnnouncement = () => {
    router.push('/create-announcement')
}

onMounted(async () => {
    const response = await axios.get('https://localhost:44315/api/Advertisement?pageNumber=1&pageSize=10&sortBy=priceAsc')
    items.value = response.data.result
    console.log(response)
})
</script>

<style scoped>
body {
    font-family: 'Arial', sans-serif;
    background-color: #2b2b2b;
    color: #f5f5f5;
}

.announcement-list {
    display: flex;
    flex-wrap: wrap;
    gap: 20px;
    margin: 20px;
}

.announcement-item {
    border: 2px solid #e89e9e;
    padding: 10px;
    border-radius: 5px;
    cursor: pointer;
    transition: transform 0.2s, box-shadow 0.2s;
    flex: 1;
    min-width: 300px;
    background-color: #3a3a3a;
}

.announcement-item:hover {
    transform: scale(1.05);
    box-shadow: 0 8px 15px rgba(0, 0, 0, 0.2);
}

.announcement-image img {
    max-width: 100%;
    border-radius: 5px;
    transition: transform 0.2s;
}

.announcement-image img:hover {
    transform: scale(1.02);
}

.announcement-details {
    margin-top: 10px;
}

h2 {
    font-size: 1.5rem;
    color: #e89e9e;
    margin: 0;
    text-shadow: 1px 1px 3px rgba(0, 0, 0, 0.5);
}

.description {
    font-size: 1rem;
    color: #ddd;
    margin: 5px 0;
}

.price {
    font-size: 1.2rem;
    color: #f3b6b6;
    margin: 5px 0;
    font-weight: bold;
}

.center-button {
    display: flex;
    justify-content: center;
    align-items: center;
    margin-top: 20px;
}

.create-button {
    padding: 10px 25px;
    background-color: #e89e9e;
    color: white;
    border: none;
    border-radius: 5px;
    cursor: pointer;
    font-size: 1.1rem;
    transition: background-color 0.2s, transform 0.2s;
}

.create-button:hover {
    background-color: #d58686;
    transform: scale(1.05);
}


.sorting-options {
    display: flex;
    justify-content: center; 
    align-items: center;
    gap: 15px;
    margin: 20px 0; 
    padding: 15px; 
    border-radius: 5px; 
    box-shadow: 0 2px 8px rgba(0, 0, 0, 0.15);
    background-color: #3a3a3a; 
}

.sorting-options label {
    font-weight: bold; 
    font-size: 1.1rem;
}

.sorting-options select, .sorting-options button {
    padding: 6px 12px; 
    border: none;
    border-radius: 5px;
    cursor: pointer;
    background-color: #e89e9e;
    color: white;
    font-size: 1rem;
    transition: background-color 0.3s; 
}

.sorting-options button:hover {
    background-color: #d58686;
}

.sorting-options select:hover, .sorting-options select:focus {
    background-color: #d58686;
}

</style>

