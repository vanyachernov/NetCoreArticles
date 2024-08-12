import Author from "./author.tsx";

export interface Article {
    id: string,
    author: Author,
    title: string,
    content: string,
    titleImage: File | null,
    views: number, 
    createdAt: Date
    updatedAt: Date
}

export interface ArticleRequest {
    authorId: string;
    title: string;
    content: string;
    titleImage: File | null;
}