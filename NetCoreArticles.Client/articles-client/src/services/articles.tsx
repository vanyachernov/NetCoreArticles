import axios from "axios";
import {ArticleRequest} from "../entities/article.tsx";

const baseUrl = "http://localhost:5212";

export const fetchArticles = async () => {
    try {
        const articlesData = await axios.get(`${baseUrl}/api/articles`);
        return articlesData.data;
    } catch (exception) {
        console.error(exception);
    }
}

export const fetchArticleByIdentifier = async (articleId: string) => {
    try {
        const articleData = await axios.get(`${baseUrl}/api/articles/${articleId}`);
        return articleData.data;
    } catch (exception) {
        console.error(exception);
        return null;
    }
}

export const createArticle = async (article: ArticleRequest) => {
    try {
        const formData = new FormData();
        formData.append('authorId', article.authorId);
        formData.append('title', article.title);
        formData.append('content', article.content);
        
        if (article.titleImage) {
            formData.append('titleImage', article.titleImage);
        }
        
        const articleProcessingResult = await axios.post(`${baseUrl}/api/articles/create`, formData, {
            headers: {
                'Content-Type': 'multipart/form-data',
            },
        });

        return articleProcessingResult.data;
    } catch (exception) {
        console.error(exception);
    }
};


export const updateArticle = async (articleId: string, article: ArticleRequest) => {
    try {
        const articleProcessingResult = await axios.post(`${baseUrl}/api/articles/${articleId}`, JSON.stringify(article));
        return articleProcessingResult.data;
    } catch (exception) {
        console.error(exception);
    }
};

export const deleteArticle = async (articleId: string) => {
    try {
        const articleProcessingResult = await axios.delete(`${baseUrl}/api/articles/${articleId}`);
        return articleProcessingResult.data;
    } catch (exception) {
        console.error(exception);
    }
};