import "../app/styles/Articles.css";
import Header from "../shared/Header.tsx";
import ArticlesFilters from "../features/ArticlesFilters.tsx";
import ArticleList from "../widgets/ArticleList.tsx";

export default function Articles() {
    return (
        <>
            <Header />
            <div className="main bg-red-50 mt-5 pb-5 h-[100vh]">
                <main className="pt-6 mx-auto container mt-5 px-4 lg:px-0">
                    <h1 className="text-center text-4xl font-bold">Articles</h1>
                    <div className="pt-6">
                        <div className="flex flex-col w-full lg:flex-row h-full">
                            <ArticlesFilters />
                            <ArticleList />
                        </div>
                    </div>
                </main>
            </div>
            <h1>Hellos</h1>
        </>
    );
}
