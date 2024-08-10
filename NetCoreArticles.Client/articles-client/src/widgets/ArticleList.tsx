import {Avatar} from "@chakra-ui/react";
import ArticleCard from "./ArticleCard.tsx";
import {useEffect, useState} from "react";
import {fetchArticles} from "../services/articles.tsx";

export default function ArticleList() {
    const [articles, setArticles] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const fetchArticlesData = async () => {
            const data = await fetchArticles();
            setArticles(data);
            setLoading(false);
        }
        fetchArticlesData();
    }, []);
    
    return (
        <div className="flex flex-row w-full lg:w-4/5 flex-wrap lg:justify-between gap-[20px]">
            {!loading ? articles.map((article) => (
                <ArticleCard key={article.id} article={article} />
            )) : (
                <div>
                    No articles data.
                </div>
            )}
        </div>
    );
}
;