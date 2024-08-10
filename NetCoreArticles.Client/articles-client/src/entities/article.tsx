import Image from "./image";
import Author from "./author.tsx";

export default interface Article {
    id: string,
    author: Author,
    title: string,
    content: string,
    image: Image
    views: number, 
    createdAt: Date
    updatedAt: Date
}