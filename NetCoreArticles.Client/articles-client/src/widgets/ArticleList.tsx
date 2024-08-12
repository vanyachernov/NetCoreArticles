import ArticleCard from "./ArticleCard.tsx";
import {Article} from "../entities/article.tsx";

interface Props {
    articles: Article[];
    loading: boolean;
}

export default function ArticleList({articles, loading}: Props) {
    return (
        <div className="flex flex-row w-full lg:w-4/5 flex-wrap lg:justify-between xl:justify-start gap-[20px]">
            {!loading ? articles.map((article) => (
                <ArticleCard key={article["id"]} article={article} />
            )) : (
                <div>
                    No articles data.
                </div>
            )}
        </div>
    );
}
;