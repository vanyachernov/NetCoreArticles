import {
    Accordion,
    AccordionItem,
    AccordionButton,
    AccordionPanel,
    AccordionIcon,
    Box,
    Input,
    Select
} from "@chakra-ui/react";

export default function ArticlesFilters({filters, setFilter}) {
    return (
        <div className="flex flex-col w-full lg:w-1/5 mr-0 lg:mr-6 mb-6 lg:mb-0 max-h-[800px]">
            <div className="p-6 flex-grow">
                <h2 className="text-2xl font-bold hidden lg:block">Filters</h2>
                <Accordion display={{base: "block", md: "block", lg: "none"}} allowToggle>
                    <AccordionItem>
                        <AccordionButton>
                            <Box as="span" flex="1" textAlign="left">Filters</Box>
                            <AccordionIcon/>
                        </AccordionButton>
                        <AccordionPanel pb={4} className="mt-2">
                            <Input
                                type="text"
                                placeholder="Article name"
                                onChange={(e) => setFilter(prevFilters => ({
                                    ...prevFilters,
                                    search: e.target.value
                                }))}
                            />
                            <div className="pt-4">
                                <div className="pt-2">
                                    <Select
                                        placeholder='By default'
                                        onChange={(e) => setFilter(prevFilters => ({
                                            ...prevFilters,
                                            sortOrder: e.target.value
                                        }))}
                                    >
                                        <option value='desc'>From new to old</option>
                                        <option value='asc'>From old to new</option>
                                    </Select>
                                </div>
                            </div>
                        </AccordionPanel>
                    </AccordionItem>
                </Accordion>
                <div className="hidden lg:block pt-4">
                    <Input
                        type="text"
                        placeholder="Article name"
                        onChange={(e) => setFilter(prevFilters => ({
                            ...prevFilters,
                            search: e.target.value
                        }))}
                    />
                    <div className="pt-4">
                        <div className="pt-2">
                            <Select
                                placeholder='By default'
                                onChange={(e) => setFilter(prevFilters => ({
                                    ...prevFilters,
                                    sortOrder: e.target.value
                                }))}
                            >
                                <option value='desc'>From new to old</option>
                                <option value='asc'>From old to new</option>
                            </Select>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};
