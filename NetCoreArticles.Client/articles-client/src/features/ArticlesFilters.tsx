import {
    Accordion,
    AccordionItem,
    AccordionButton,
    AccordionPanel,
    AccordionIcon,
    Box,
    Input,
    RangeSlider,
    RangeSliderTrack,
    RangeSliderFilledTrack,
    RangeSliderThumb
} from "@chakra-ui/react";

export default function ArticlesFilters() {
    return (
        <div className="flex flex-col w-full lg:w-1/5 bg-white mr-0 lg:mr-6 rounded-lg shadow-md mb-6 lg:mb-0 h-full">
            <div className="p-6 flex-grow">
                <h2 className="text-2xl font-bold hidden lg:block">Filters</h2>
                <Accordion display={{base: "block", md: "block", lg: "none"}} allowToggle>
                    <AccordionItem>
                        <AccordionButton>
                            <Box as="span" flex="1" textAlign="left">Filters</Box>
                            <AccordionIcon/>
                        </AccordionButton>
                        <AccordionPanel pb={4} className="mt-2">
                            <Input type="text" placeholder="Article name"/>
                            <div className="pt-4">
                                <div className="flex items-center justify-between text-center flex-row">
                                    <Input disabled type="text" className="w-1/3"/>
                                    <span className="w-1/3">-</span>
                                    <Input disabled type="text" className="w-1/3"/>
                                </div>
                                <div className="pt-2">
                                    <RangeSlider aria-label={['min', 'max']} colorScheme="teal" defaultValue={[0, 100]}>
                                        <RangeSliderTrack>
                                            <RangeSliderFilledTrack/>
                                        </RangeSliderTrack>
                                        <RangeSliderThumb index={0}/>
                                        <RangeSliderThumb index={1}/>
                                    </RangeSlider>
                                </div>
                            </div>
                        </AccordionPanel>
                    </AccordionItem>
                </Accordion>
                <div className="hidden lg:block pt-4">
                    <Input type="text" placeholder="Article name"/>
                    <div className="pt-4">
                        <div className="flex items-center justify-between text-center flex-row">
                            <Input disabled type="text" className="w-1/3"/>
                            <span className="w-1/3">-</span>
                            <Input disabled type="text" className="w-1/3"/>
                        </div>
                        <div className="pt-2">
                            <RangeSlider aria-label={['min', 'max']} colorScheme="teal" defaultValue={[0, 100]}>
                                <RangeSliderTrack>
                                    <RangeSliderFilledTrack/>
                                </RangeSliderTrack>
                                <RangeSliderThumb index={0}/>
                                <RangeSliderThumb index={1}/>
                            </RangeSlider>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};
