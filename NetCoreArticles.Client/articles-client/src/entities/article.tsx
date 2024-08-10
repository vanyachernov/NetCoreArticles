export default interface Article {
    id: string,
    authorId: string,
    title: string,
    content: string,
    articleImage: {
        articleId: string,
        fileName: string
    },
    views: number, 
    createdAt: Date
    updatedAt: Date
}