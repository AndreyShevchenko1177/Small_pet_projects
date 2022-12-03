import { useContext } from 'react';
import ThemeContext from './theme';

const ThemeButton = (props) => {

    console.log({ props });

    const [context, setContext] = useContext(ThemeContext)

    return (
        <button onClick={() => setContext("New Value")}>
            button with theme: {context} + {JSON.stringify(props)}
        </button>
    )
}

export default ThemeButton;