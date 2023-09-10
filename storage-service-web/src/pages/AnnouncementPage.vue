<template>
    <div v-if="announcement" class="page-container">
        <div class="content-wrapper">
            <div class="announcement-full">
                <div class="announcement-image">
                    <img :src="announcement.imageUrl" alt="Announcement Image" />
                </div>
                <div class="announcement-details">
                    <h2>{{ announcement.title }}</h2>
                    <p class="description">{{ announcement.description }}</p>
                    <p class="price">{{ announcement.price }} грн</p>
                </div>
            </div>
            <div class="button-wrapper">
                <button @click="goToHomePage" class="home-button">Повернутись на Головну</button>
            </div>
        </div>
    </div>
</template>


<script>
import axios from 'axios'

export default {
    name: "AnnouncementPage",
    data() {
        return {
            announcement: null
        };
    },
    methods: {
        goToHomePage() {
            this.$router.push({ name: 'HomePage' });
        }
    },
    async created() {
        const id = this.$route.params.id;
        const response = await axios.get(`https://localhost:44315/api/Advertisement/${id}`);
        this.announcement = response.data.result;
    }
}
</script>

<style scoped>

.page-container {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    min-height: 100vh;
    background-color: #2b2b2b;
    color: #f5f5f5;
}

.content-wrapper {
    width: 80%;
    max-width: 1200px;
}

.button-wrapper {
    display: flex;
    justify-content: center;
    margin-top: 20px;
}

.announcement-full {
    display: flex;
    border: 2px solid #e89e9e;
    border-radius: 5px;
    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
    padding: 20px;
    background-color: #3a3a3a;
    margin: 20px 0;
    transition: box-shadow 0.3s ease;
}

.announcement-full:hover {
    box-shadow: 0 6px 10px rgba(0, 0, 0, 0.15);
}

.announcement-image {
    flex: 1;
    border-right: 1px solid #e89e9e;
    padding-right: 20px;
    margin-right: 20px;
}

.announcement-image img {
    max-width: 100%;
    height: auto;
    border-radius: 5px;
}

.announcement-details {
    flex: 2;
    display: flex;
    flex-direction: column;
    justify-content: space-between;
}

h2 {
    font-size: 2rem;
    margin: 0 0 15px 0;
    color: #e89e9e;
    text-shadow: 1px 1px 3px rgba(0, 0, 0, 0.5);
}

.description {
    font-size: 1rem;
    color: #ddd;
    margin-bottom: 10px;
    line-height: 1.5;
}

.price {
    font-size: 1.6rem;
    color: #f3b6b6;
    font-weight: bold;
    margin-top: auto;
}

.home-button {
    display: inline-block;
    padding: 10px 20px;
    background-color: #e89e9e;
    color: #f5f5f5;
    font-size: 1rem;
    border: none;
    border-radius: 5px;
    cursor: pointer;
    transition: background-color 0.3s ease;
    margin-bottom: 20px;
}

.home-button:hover {
    background-color: #d58686;
}

@media (max-width: 768px) {
    .announcement-full {
        flex-direction: column;
    }

    .announcement-image {
        margin-right: 0;
        padding-right: 0;
        border-right: none;
        margin-bottom: 15px;
    }
}
</style>
