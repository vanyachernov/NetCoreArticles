import "../app/styles/Articles.css";
import Header from "../shared/Header.tsx";
import ArticlesFilters from "../features/ArticlesFilters.tsx";
import ArticleList from "../widgets/ArticleList.tsx";
import {useEffect, useState} from "react";
import {Article, ArticleRequest} from "../entities/article.tsx";
import {createArticle, fetchArticles} from "../services/articles.tsx";
import Footer from "../shared/Footer.tsx";

export default function Articles() {
    const [articles, setArticles] = useState<Article[]>([]);
    const [loading, setLoading] = useState(true);
    
    const loadArticles = async () => {
        const fetchedArticles = await fetchArticles();
        
        setLoading(false);
        setArticles(fetchedArticles);
    };
    
    useEffect(() => {
        loadArticles();
    }, []);
    
    const handleCreateArticle = async (request: ArticleRequest) => {
        await createArticle(request);
        await loadArticles();
    };
    
    return (
        <>
            <Header onCreateArticle={handleCreateArticle} />
            <div className="main mt-5 pb-5 h-[100vh]">
                <main className="pt-6 mx-auto container mt-5 px-4 lg:px-0">
                    <h1 className="text-center text-4xl font-bold">Articles</h1>
                    <div className="pt-6">
                        <div className="flex flex-col w-full lg:flex-row h-full">
                            <ArticlesFilters />
                            <ArticleList articles={articles} loading={loading} />
                        </div>
                    </div>
                </main>
            </div>
            <Footer />
        </>
    );
}
