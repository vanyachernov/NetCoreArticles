import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import { ChakraProvider } from "@chakra-ui/react";
import Articles from "./pages/Articles.tsx";
import "./app/styles/index.css";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import ArticleDetails from "./pages/ArticleDetails.tsx";

createRoot(document.getElementById("root")!).render(
    <StrictMode>
        <ChakraProvider>
            <Router>
                <Routes>
                    <Route path="/articles" element={<Articles />} />
                    <Route path="/articles/:id" element={<ArticleDetails />} />
                </Routes>
            </Router>
        </ChakraProvider>
    </StrictMode>
);
