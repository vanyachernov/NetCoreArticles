import "../app/styles/Articles.css";
import {useEffect, useState} from "react";
import {Article} from "../entities/article.tsx";
import {fetchArticleByIdentifier} from "../services/articles.tsx";
import {useNavigate, useParams} from "react-router-dom";
import ArticleDetailsCard from "../widgets/ArticleDetailsCard.tsx";
import { IoMdArrowRoundBack } from "react-icons/io";
import Footer from "../shared/Footer.tsx";
import Header from "../shared/Header.tsx";

export default function ArticleDetails() {
    const [article, setArticle] = useState<Article>();
    const [loading, setLoading] = useState(true);
    const { id } = useParams();
    const navigate = useNavigate();
    
    useEffect(() => {
        const loadArticle = async () => {
            const fetchedArticle = await fetchArticleByIdentifier(id!);

            setLoading(false);
            setArticle(fetchedArticle);
        };
        
        loadArticle();
    }, [id]);
    
    return (
        <>
            <div className="main mt-5 pb-5 h-[100vh]">
                <main className="pt-6 mx-auto container mt-5 px-4 lg:px-0">
                    <button
                        className="font-bold text-[20px] text-black-500 hover:underline mb-4"
                        onClick={() => navigate(-1)}
                    >
                            <span className="flex items-center gap-3">
                                <IoMdArrowRoundBack/> Back
                            </span>
                    </button>
                    <h1 className="text-center text-4xl font-bold">{article?.title}</h1>
                    <div className="px-30">
                        {!loading ? (
                            <ArticleDetailsCard article={article}/>
                        ) : (
                            <div>
                                Article not found!
                            </div>
                        )}
                    </div>
                </main>
            </div>
            <Footer />
        </>
    );
}
