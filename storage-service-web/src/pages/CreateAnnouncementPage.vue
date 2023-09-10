<template>
    <div class="container">
        <form @submit.prevent="submitForm">
            <div>
                <label for="title">Назва:</label>
                <input type="text" id="title" v-model="formData.Title" required maxlength="200" />
            </div>

            <div>
                <label for="description">Опис:</label>
                <textarea id="description" v-model="formData.Description" maxlength="1000"></textarea>
            </div>

            <div>
                <label for="imageUrl">URL Зображення:</label>
                <input type="text" id="imageUrl" v-model="formData.ImageUrl" maxlength="255" />
            </div>

            <div>
                <label for="price">Ціна:</label>
                <input type="number" id="price" v-model="formData.Price" required />
            </div>

            <div class="buttons-container">
                <button type="button" @click="goToHomePage">Повернутися на головну</button>
                <button type="submit">Створити оголошення</button>
            </div>
        </form>
    </div>
</template>

<script>
import axios from 'axios';

export default {
    name: "CreateAnnouncementPage",
    data() {
        return {
            formData: {
                Title: '',
                Description: '',
                ImageUrl: '',
                Price: 0
            }
        };
    },
    methods: {
        async submitForm() {
            try {
                const response = await axios.post('https://localhost:44315/api/Advertisement', this.formData);
                if(response.data.IsSuccess) {
                    this.$router.push('/');
                }
            } catch (error) {
                console.error("An error occurred:", error);
            }
        },
        goToHomePage() {
            this.$router.push('/');
        }
    }
}
</script>

<style scoped>
body {
    font-family: 'Arial', sans-serif;
    background-color: #2b2b2b;
    color: #f5f5f5;
}

.container {
    width: 100%;
    max-width: 600px;
    margin: 2rem auto;
    padding: 2rem;
    background-color: #3a3a3a;
    box-shadow: 0 8px 15px rgba(0, 0, 0, 0.2);
    border: 2px solid #e89e9e;
    border-radius: 5px;
}

label {
    display: block;
    margin-bottom: 0.5rem;
    font-weight: bold;
    color: #e89e9e;
    text-shadow: 1px 1px 3px rgba(0, 0, 0, 0.5);
}

input[type="text"], textarea, input[type="number"] {
    width: 100%;
    padding: 0.8rem 1rem;
    margin: 0.5rem 0 1.5rem 0;
    border: 1px solid #ddd;
    border-radius: 5px;
    font-size: 1rem;
    color: #ddd;
    background-color: #2b2b2b;
    line-height: 1.5;
    transition: border-color 0.3s;
}

input[type="text"]:focus, textarea:focus, input[type="number"]:focus {
    border-color: #e89e9e;
    outline: none;
}

textarea {
    resize: vertical;
    min-height: 100px;
}

button {
    padding: 10px 25px;
    background-color: #e89e9e;
    color: white;
    border: none;
    border-radius: 5px;
    cursor: pointer;
    font-size: 1.1rem;
    transition: background-color 0.2s, transform 0.2s;
}

button:hover {
    background-color: #d58686;
    transform: scale(1.05);
}

.buttons-container {
    display: flex;
    justify-content: center;
    gap: 1rem;
}
</style>
