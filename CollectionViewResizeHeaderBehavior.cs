using System;

namespace JSGradesMini;

public class CollectionViewResizeHeaderBehavior : Behavior<CollectionView>
{
    protected override void OnAttachedTo( CollectionView bindable )
    {

        /*
         * BC 10/17/2023
         * This is some iOS specific code that is needed to force the header to resize when the inner content is resized.
         * This is a bug in .NET MAUI, and we can track the progress here: https://github.com/dotnet/maui/issues/17885
         */
#if IOS || MACCATALYST
        if ( bindable.Header is VisualElement element )
        {
            bindable.Dispatcher.Dispatch( () =>
            {
                element.InvalidateMeasureNonVirtual( ( Microsoft.Maui.Controls.Internals.InvalidationTrigger.Undefined ) );
            } );
        }
#endif

        base.OnAttachedTo( bindable );
    }
}        
