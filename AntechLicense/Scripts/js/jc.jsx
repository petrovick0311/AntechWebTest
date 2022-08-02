import React from 'react';
import { ReworthDirectory } from '@reworthrewards/reworth-directory';

class DirectoryR extends React.Component {
    render() {
        return (
            <ReworthDirectory
                accentColor={'#2E58FF'}
                lang={'ES'}
                fontFamily={'Poppins'}
            />
        )
    }
}

const Directory = () => {
    return (
        <ReworthDirectory
            accentColor={'#2E58FF'}
            lang={'ES'}
            fontFamily={'Poppins'}
        />
    )
}

React.render(<Directory />, document.getElementById("Comp"))
