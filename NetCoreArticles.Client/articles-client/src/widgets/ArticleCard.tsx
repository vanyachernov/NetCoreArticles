import {Avatar} from "@chakra-ui/react";
import {BsBarChartFill} from "react-icons/bs";
import moment from "moment";
import {Article} from "../entities/article.tsx";
import {useNavigate} from "react-router-dom";

interface ArticleProps {
    article: Article
}

export default function ArticleCard({article}: ArticleProps) {
    const baseUrl = "http://localhost:5212/articles/images";
    const navigate = useNavigate();

    const onHandleArticleDetails = () => {
        navigate(`/articles/${article.id}`);
    };
    
    return (
        <article
            className="flex flex-col w-full xl:max-w-[490px] 2xl:max-w-[385px] lg:max-w-[385px] md:max-w-full bg-white rounded-lg shadow-md overflow-hidden"
            style={{maxHeight: '300px'}}>
            <div className="p-6 flex-grow overflow-auto">
                <h2 className="text-[18px] font-bold mb-2 line-clamp-2">{article.title}</h2>
                <div className="flex items-center justify-between mt-4">
                    <div className="flex items-center">
                        <Avatar className="mr-3" name={article.author.username} src={`${baseUrl}/${article.author.image.fileName}`} />
                        <div className="text-sm">
                            <p className="text-gray-900 md:max-w-full lg:max-w-[300px] leading-4">{article.author.username}</p>
                            <p className="text-gray-600 mt-2">{moment(article.createdAt).format("DD.MM.YYYY hh:mm")}</p>
                        </div>
                    </div>
                    <div className="text-gray-600 flex items-center">
                        <BsBarChartFill className="mr-2"/>
                        <div className="flex items-center gap-1">
                            <span className="text-[14px]">{article.views - 1}</span>
                            <span className="text-[14px]">views</span>
                        </div>
                    </div>
                </div>
            </div>
            <div className="p-6">
                <button
                    onClick={onHandleArticleDetails}    
                    className="bg-teal-500 text-white text-sm font-bold py-2 px-4 rounded hover:bg-teal-600 w-full">
                    Read More
                </button>
            </div>
        </article>
    );
}
