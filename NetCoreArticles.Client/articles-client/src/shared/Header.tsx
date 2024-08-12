import ArticleManage, {Mode} from "../features/ArticleManage.tsx";
import {useDisclosure} from "@chakra-ui/react";
import {useState} from "react";
import {Article, ArticleRequest} from "../entities/article.tsx";

interface Props {
    onCreateArticle: (request: ArticleRequest) => void;
}

export default function Header({onCreateArticle}: Props) {
    const {isOpen,onOpen,onClose} = useDisclosure();
    const defaultValues = {
        id: "",
        author: {
            id: "",
            username: "",
            email: ""
        },
        title: "",
        content: "",
        titleImage: null,
        views: 0,
        createdAt: new Date(),
        updatedAt: new Date(),
    } as Article;
    const [article, setArticle] = useState<Article>(defaultValues);
    
    const handleCreateArticle = async (request: ArticleRequest) => {
        await onCreateArticle(request);
        setArticle(defaultValues);
        onClose();
    };

    const handleUpdateArticle = async (id: string,  request: ArticleRequest) => {
        
    };
    
    return (
    <>
        <header className="container mx-auto px-4 lg:px-0">
            <div className="flex justify-between items-center pt-5">
                <span className="font-bold text-3xl">Copywriter</span>
                <div className="space-x-5 align-middle">
                    <a href="#" onClick={onOpen} className="cursor-pointer hover:text-teal-400 transition duration-200">New post</a>
                    <a href="#" className="cursor-pointer hover:text-teal-400 transition duration-200">About</a>
                    <a href="#" className="bg-teal-500 py-2 px-4 rounded-full text-white">Sign In</a>
                </div>
            </div>
        </header>

        <ArticleManage
            mode={Mode.Create}
            article={article}
            isModalOpen={isOpen}
            handleCancel={onClose}
            handleCreate={handleCreateArticle}
            handleUpdate={handleUpdateArticle}
        />
    </>
    );
};