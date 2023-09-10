<template>
    <div v-if="announcement">
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
    async created() {
        const id = this.$route.params.id; 
        const response = await axios.get(`https://localhost:44315/api/Advertisement/${id}`);
        this.announcement = response.data.result;
    }
}
</script>

<style scoped>
.announcement-full {
    display: flex;
    border: 1px solid #e0e0e0;
    border-radius: 5px;
    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
    padding: 20px;
    background-color: #fff;
    margin: 20px 0;
    transition: box-shadow 0.3s ease;
}

.announcement-full:hover {
    box-shadow: 0 6px 10px rgba(0, 0, 0, 0.15);
}

.announcement-image {
    flex: 1;
    border-right: 1px solid #e0e0e0;
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
    color: #333;
}

.description {
    font-size: 1rem;
    color: #666;
    margin-bottom: 10px;
    line-height: 1.5;
}

.price {
    font-size: 1.6rem;
    color: #2E8B57; /* Seagreen color for a fresh look */
    font-weight: bold;
    margin-top: auto; /* push it to the bottom if there's extra space */
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
