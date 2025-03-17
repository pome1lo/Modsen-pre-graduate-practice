import Header from "../components/Header.jsx";
import Footer from "../components/Footer.jsx";

function BasicLayout({children}) {
    return (
        <div className="flex flex-col min-h-screen">
            <Header/>
            <main className="flex-grow container mx-auto mt-5 p-4">
                {children}
            </main>
            <Footer/>
        </div>
    );
};

export default BasicLayout;