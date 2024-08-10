import React from 'react';

export default function Header() {
    return (
        <header className="container mx-auto px-4 lg:px-0">
            <div className="flex justify-between items-center pt-5">
                <span className="font-bold text-3xl">Copywriter</span>
                <div className="space-x-5 align-middle">
                    <a href="#" className="cursor-pointer hover:text-teal-400 transition duration-200">New post</a>
                    <a href="#" className="cursor-pointer hover:text-teal-400 transition duration-200">About</a>
                    <a href="#" className="bg-teal-500 py-2 px-4 rounded-full text-white">Sign In</a>
                </div>
            </div>
        </header>
    );
};