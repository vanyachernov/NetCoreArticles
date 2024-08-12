import "../app/styles/Articles.css";
import {useEffect, useState} from "react";
import {Article} from "../entities/article.tsx";
import ArticleDetailsCard from "../widgets/ArticleDetailsCard.tsx";
import {fetchArticleByIdentifier} from "../services/articles.tsx";
import {useNavigate, useParams} from "react-router-dom";
import Footer from "../shared/Footer.tsx";
import {Button} from "@chakra-ui/react";
import { MdDeleteOutline } from "react-icons/md";
import {IoMdArrowRoundBack} from "react-icons/io";
import {useDisclosure} from "@chakra-ui/react";
import ArticleDeleteAlert from "../features/ArticleDeleteAlert.tsx";
import {deleteArticle} from "../services/articles.tsx";

export default function ArticleDetails() {
    const [article, setArticle] = useState<Article | null>(null);
    const [loading, setLoading] = useState(true);
    const { id } = useParams();
    const navigate = useNavigate();
    const {isOpen,onOpen,onClose} = useDisclosure();
    
    useEffect(() => {
        const loadArticle = async () => {
            const fetchedArticle = await fetchArticleByIdentifier(id!);

            setLoading(false);
            setArticle(fetchedArticle);
        };
        
        loadArticle();
    }, [id]);

    const handleDeleteArticle = async (id: string) => {
        await deleteArticle(id);
        navigate(-1);
        onClose();
    };
    
    return (
        <>
            <div className="main mt-5 pb-5 h-[100vh]">
                <main className="pt-6 mx-auto container mt-5 px-4 lg:px-0">
                    <div className="flex justify-between">
                        <Button
                            className="font-bold text-[20px] text-black-500 mb-4"
                            colorScheme="teal"
                            onClick={() => navigate(-1)}
                        >
                            <span className="flex items-center gap-3">
                                <IoMdArrowRoundBack/> Back
                            </span>
                        </Button>
                        <Button
                            className="font-bold text-[20px] text-black-500 mb-4 flex items-center gap-2"
                            colorScheme="red"
                            onClick={onOpen}
                            >
                            <MdDeleteOutline/> Delete article
                        </Button>
                    </div>
                    <h1 className="text-center text-4xl font-bold mb-8">{article?.title}</h1>
                    <div className="px-30 flex justify-center">
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

            <ArticleDeleteAlert
                articleId={id!}
                isModalOpen={isOpen}
                handleCancel={onClose}
                handleDelete={handleDeleteArticle}
            />
        </>
    );
}
