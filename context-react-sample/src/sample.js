import React, { useState } from "react";
import ThemeContext from './theme';
import ThemeButton from './ThemedButton';

const Sample  = () => {
    const [context, setContext] = useState("default context value");
    return (
    <ThemeContext.Provider value = {[context, setContext]}>

        <ThemeContext.Consumer>
            {([context]) => <div>Oue theme is: {context}</div>}
        </ThemeContext.Consumer>

        <ThemeButton justProps = {'2'}/>


    </ThemeContext.Provider>
)};

export default Sample;