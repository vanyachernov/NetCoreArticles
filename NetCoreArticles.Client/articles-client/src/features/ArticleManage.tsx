import {
    Button,
    FormControl,
    FormLabel,
    Input,
    Modal,
    ModalBody,
    ModalCloseButton,
    ModalContent,
    ModalHeader,
    ModalFooter,
    ModalOverlay,
    Textarea,
    Image, 
    Flex
} from "@chakra-ui/react";
import {useEffect, useState} from "react";
import {Article, ArticleRequest} from "../entities/article.tsx";

const defaultTitleImageSrc = "/images/articles-default.webp"

interface Props {
    mode: Mode;
    article: Article;
    isModalOpen: boolean;
    handleCancel: () => void;
    handleCreate: (request: ArticleRequest) => void;
    handleUpdate: (id: string, request: ArticleRequest) => void;
}

export enum Mode {
    Create,
    Edit
}

export default function ArticleManage({ mode, article, isModalOpen, handleCancel, handleCreate, handleUpdate }: Props) {
    const [authorId, setAuthorId] = useState<string>("");
    const [title, setTitle] = useState<string>("");
    const [content, setContent] = useState<string>("");
    const [titleImage, setTitleImage] = useState<File | null>(null);
    const [selectedFileSrc, setSelectedFileSrc] = useState<string>(defaultTitleImageSrc);

    useEffect(() => {
        if (mode === Mode.Edit) {
            setAuthorId(article.author.id);
            setTitle(article.title);
            setContent(article.content);
            setTitleImage(article.titleImage);
        }
    }, [article, mode]);
    
    const handleChange = (file: File | null) => {
        if (file) {
            setTitleImage(file);
            const reader = new FileReader();
            reader.onload = (x) => {
                if (x.target?.result) {
                    setSelectedFileSrc(x.target.result as string);
                }
            };
            reader.readAsDataURL(file);
        } else {
            setTitleImage(null);
        }
    }
    
    const onHandleCancel = async () => {
        setTitleImage(null);
        setSelectedFileSrc(defaultTitleImageSrc);
        handleCancel();
    }
    
    const onHandleOk = async () => {
        if (!titleImage) {
            console.error("Please, upload an image before saving.");
            return;
        }

        const currentAuthorId = mode === Mode.Edit ? article.author.id : "3eb0358f-cc42-4c3e-81f4-e5debc771f7b";
        
        const articleRequest: ArticleRequest = {
            authorId: currentAuthorId,
            title,
            content,
            titleImage
        };

        mode === Mode.Create
            ? handleCreate(articleRequest)
            : handleUpdate(article.id, articleRequest);
    } 

    return (
        <Modal
            isOpen={isModalOpen}
            onClose={handleCancel}
            motionPreset='slideInBottom'
        >
            <ModalOverlay />
            <ModalContent>
                <ModalHeader>{mode === Mode.Create ? "Create new article" : "Editing article"}</ModalHeader>
                <ModalCloseButton onClick={handleCancel} />
                <ModalBody pb={6}>
                    <FormControl>
                        <FormLabel>Title</FormLabel>
                        <Input onChange={(e) => setTitle(e.target.value)} placeholder='Article title' required />
                    </FormControl>
                    <FormControl mt={4}>
                        <FormLabel>Content</FormLabel>
                        <Textarea onChange={(e) => setContent(e.target.value)} placeholder='Article content' required />
                    </FormControl>
                    <FormControl mt={4}>
                        <FormLabel>Image</FormLabel>
                        <Flex className="flex justify-center pb-4">
                            <Image className="w-[300px] h-auto" src={selectedFileSrc} />
                        </Flex>
                        <Input type="file" accept="image/*,.png,.jpg,.gif,.webp" onChange={(e) => handleChange(e.target.files![0])} />
                    </FormControl>
                </ModalBody>

                <ModalFooter>
                    <Button colorScheme='teal' mr={3} onClick={onHandleOk}>
                        {mode === Mode.Create ? "Add" : "Save"}
                    </Button>
                    <Button onClick={onHandleCancel}>Cancel</Button>
                </ModalFooter>
            </ModalContent>
        </Modal>
    );
}

