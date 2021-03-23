import React from 'react';
import { IShelterCard } from '../interfaces/Interfaces';

type ShelterHomeTabProps = {
    shelter: IShelterCard
}

export const ShelterHomeTab = (data: ShelterHomeTabProps) => {
    var exists = data.shelter.description != null && data.shelter.description != "";
    return (
        <>
            <div className="row shelter-profile_tabs_tab" style={{ whiteSpace: "pre-line" }}>
                <div className="row">
                    <h5 className="center-align orange-text">A little bit about us</h5>
                </div>
                {exists ?
                    <p>{data.shelter.description}</p>
                    :
                    <p>...</p>
                }
            </div>
        </>
    )
}