import {Avatar} from "@chakra-ui/react";
import {BsBarChartFill} from "react-icons/bs";
import moment from "moment";
import Article from "../entities/article.tsx";
import {useNavigate} from "react-router-dom";

interface ArticleProps {
    article: Article
}

export default function ArticleDetailsCard({article}: ArticleProps) {
    const baseUrl = "http://localhost:5212/articles/images";

    return (
        <div className="container mx-auto px-4 lg:px-0 mt-8">
            <div className="flex flex-col items-center max-w-full">
                <img
                    src={`${baseUrl}/${article.image.fileName}`}
                    alt={article.title}
                    className="max-w-full max-h-[500px] overflow-hidden object-cover shadow-md mb-5"
                />

                <div className="flex items-center mb-6">
                    <Avatar name={article.author.username} className="mr-4"/>
                    <div>
                        <p className="text-lg font-bold">{article.author.username}</p>
                        <p className="text-sm text-gray-600">{moment(article.createdAt).format("DD.MM.YYYY hh:mm")}</p>
                    </div>
                </div>

                <div className="w-full max-w-2xl text-left">
                    <p className="text-lg text-gray-800 leading-relaxed">
                        {article.content}
                    </p>
                </div>
            </div>
        </div>


        // <div className="text-gray-600 flex items-center">
        //     <BsBarChartFill className="mr-2"/>
        //     <div className="flex items-center gap-1">
        //         <span className="text-[14px]">{article.views}</span>
        //         <span className="text-[14px]">views</span>
        //     </div>
        // </div>
    );
};
