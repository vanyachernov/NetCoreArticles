import {
    AlertDialog,
    AlertDialogBody,
    AlertDialogContent, 
    AlertDialogFooter,
    AlertDialogHeader,
    AlertDialogOverlay, 
    Button
} from "@chakra-ui/react";

interface Props {
    articleId: string;
    isModalOpen: boolean;
    handleCancel: () => void;
    handleDelete: (id: string) => void;
}

export default function ArticleDeleteAlert({articleId, isModalOpen, handleCancel, handleDelete}: Props) {
    const onHandleOk = async () => {
        await handleDelete(articleId);
    }
    
    return (
        <AlertDialog
            isOpen={isModalOpen}
            onClose={handleCancel}
            isCentered>
            <AlertDialogOverlay>
                <AlertDialogContent>
                    <AlertDialogHeader fontSize='lg' fontWeight='bold'>
                        Delete Article
                    </AlertDialogHeader>
                
                    <AlertDialogBody>
                        Are you sure? You can't undo this action afterwards.
                    </AlertDialogBody>
        
                    <AlertDialogFooter>
                        <Button onClick={handleCancel}>
                            Cancel
                        </Button>
                        <Button colorScheme='red' onClick={onHandleOk} ml={3}>
                            Delete
                        </Button>
                    </AlertDialogFooter>
                </AlertDialogContent>
            </AlertDialogOverlay>
        </AlertDialog>
    );
};