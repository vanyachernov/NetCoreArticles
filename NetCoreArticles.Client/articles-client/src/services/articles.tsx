import axios from "axios";
import {Article} from "../entities/article.tsx";

const baseUrl = "http://localhost:5212";

export const fetchArticles = async () => {
    try {
        const articlesData = await axios.get(`${baseUrl}/api/articles`);
        console.log(articlesData.data);
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

export const createArticle = async (article: Article) => {
    try {
        const articleModel = [
            article.Title,
            article.Content
        ];
        const articleProcessingResult = await axios.post(`${baseUrl}/api/articles/create`, articleModel);
        return articleProcessingResult.data;
    } catch (exception) {
        console.error(exception);
    }
};

export const updateArticle = async (article: Article) => {
    try {
        const articleModel = [
            article.AuthorId,
            article.Title,
            article.Content,
            article.Image
        ];
        const articleProcessingResult = await axios.post(`${baseUrl}/api/articles/${article.Id}`, articleModel);
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